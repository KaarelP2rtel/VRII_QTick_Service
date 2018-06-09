
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Location
    {
        #region Body of Location
        //Entity properties
        public int LocationId { get; set; }
        [MaxLength(100)]
        public string LocationName { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(1000)]
        public string LocationDescription { get; set; }
        [MaxLength(200)]
        public string LocationContact { get; set; }
        #endregion

        #region Event Performance Location creator
        //Table relations
        [Required]
        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }
        #endregion

        #region List of Event Performances Creator
        public List<Performance> Performances { get; set; }
        #endregion
    }
}
