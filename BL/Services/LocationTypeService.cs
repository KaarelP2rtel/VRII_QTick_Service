﻿using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class LocationTypeService : ILocationTypeSerivce
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILocationTypeFactory _locationTypeFactory;

        public LocationTypeService(IAppUnitOfWork uow, ILocationTypeFactory locationTypeFactory)
        {
            _uow = uow;
            _locationTypeFactory = locationTypeFactory;
        }

        public LocationTypeDTO AddNewLocationType(LocationTypeDTO newLocationType)
        {
            var lt = _locationTypeFactory.Transform(newLocationType);
            _uow.LocationTypes.Add(lt);
            _uow.SaveChanges();
            return _locationTypeFactory.Transform(lt);
        }

        public List<LocationTypeDTO> GetAllLocationTypes()
        {
            return _uow.LocationTypes
                .All()
                .Select(lt => _locationTypeFactory.Transform(lt))
                .ToList();

        }

        public LocationTypeDTO GetLocationTypeById(int id)
        {
             return _locationTypeFactory.Transform(_uow.LocationTypes.Find(id));
        }
    }
}