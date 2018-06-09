 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    /// <summary>
    /// This class holds all of the information on Event domain class. 
    /// Anything changed here will change in the database. 
    /// </summary>
    public class Event
    {
        #region Body of the Event
        //Event properties
        public int EventId { get; set; }
        [MaxLength(100)]
        public string EventName { get; set; }
        [MaxLength(1000)]
        public string EventDescription { get; set; }
        [MaxLength(500)]
        public string ImageLink { get; set; }
        [MaxLength(200)]
        public string EventDuration { get; set; }
        [MaxLength(100)]
        public string EventPage { get; set; }
        #endregion

        #region EventType Creator
        //Table Relations
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        #endregion

        #region Performance List Creator
        public List<Performance> Performances { get; set; }
        #endregion
    }
}
