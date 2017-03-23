using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ETWReader;
using Models;
using ETWDataService;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace RestAPI.Controllers
{
    /// <summary>
    /// Controller that handles adding, removing, and displaying Event Sources and their accompanying events.
    /// </summary>
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private IETWDataService Events;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="events">EventDataService to be used by the controller for adding, removing, and retrieving Event Readers and Events</param>
        public EventsController(IETWDataService events)
        {
            Events = events;
        }

        /// <summary>
        /// Add a new event source using an AddETWRequest to specify the source data and source type
        /// </summary>
        /// <param name="request">AddETWRequest</param>
        /// <returns>IActionResult with the GUID of the newly added source or an ErrorMessage object</returns>
        [HttpPut("/api/v1/events/addsourcefromstring")]
        public IActionResult AddEventsFromString([FromBody] AddETWRequest request)
        {
            try
            {
                ETWReaderFactory factory = new ETWReader.ETWReaderFactory();
                AbstractETWReader reader = factory.CreateReader(request.SourceType);

                Guid SourceId = Events.AddETWData(Guid.NewGuid(), reader.ReadEvents(request.Source));

                return new OkObjectResult(SourceId);
            }
            catch (System.UnauthorizedAccessException exception)
            {
                return BadRequest(new ErrorMessage("This application requires additional authorization to access this log. Please log in as administrator or add permissions to the user running this application.", exception));
            }
            catch (FileNotFoundException exception)
            {
                return BadRequest(new ErrorMessage("Error reading events from the specified source.", exception));
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorMessage("An unexpected error as occured. See the message and stacktrace for more information.", exception));
            }
        }

        /// <summary>
        /// Get all events currently contained in the ETWDataService
        /// </summary>
        /// <returns>IActionResult with all Events or ErrorMessage object</returns>
        [HttpGet("/api/v1/events")]
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(Events.GetEventsFromAllReaders());
            }
            catch (System.UnauthorizedAccessException exception)
            {
                return BadRequest(new ErrorMessage("This application requires additional authorization to access this log. Please log in as administrator or add permissions to the user running this application.", exception));
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorMessage("An unexpected error as occured. See the message and stacktrace for more information.", exception));
            }
        }

        /// <summary>
        /// Get events from a specific source by ID
        /// </summary>
        /// <param name="id">Guid of requested source</param>
        /// <returns>IActionResult with an array of the selected events or an ErrorMessage object</returns>
        [HttpGet("/api/v1/events/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return new OkObjectResult(Events.GetEventsFromReader(id));
            }
            catch (KeyNotFoundException exception)
            {
                return BadRequest(new ErrorMessage("The ID you entered was null. Please supply a valid id. See the message and stacktrace for more information.", exception));
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorMessage("An unexpected error as occured. See the message and stacktrace for more information.", exception));
            }
        }

        /// <summary>
        /// Removes a source and its events from the ETWDataService by source ID
        /// </summary>
        /// <param name="id">Guid of source to delete from ETWDataService</param>
        /// <returns>IActionResult of SuccessMessage or ErrorMessage</returns>
        [HttpDelete("/api/v1/events/remove/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Events.RemoveETWData(id);
                return new OkObjectResult(new SuccessMessage() { Success = true });
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(new ErrorMessage("Null value entered for ID. Please enter a valid id. See the message and stacktrace for more information.", exception));
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorMessage("An unexpected error as occured. See the message and stacktrace for more information.", exception));
            }
        }
    }
}
