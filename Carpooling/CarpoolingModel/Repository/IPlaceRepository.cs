using System;
namespace CarpoolingModel.Repository {
    interface IPlaceRepository {
        void addPlace(CarpoolingModel.Place place, CarpoolingModel.Route route);
        System.Collections.Generic.List<CarpoolingModel.Country> getAllCountriesOfState(CarpoolingModel.Nation state);
        System.Collections.Generic.List<CarpoolingModel.Nation> getAllStates();
        System.Collections.Generic.List<CarpoolingModel.City> getAllTownsOfCountry(CarpoolingModel.Country country);
        CarpoolingModel.City getCityById(int id);
        System.Collections.Generic.List<CarpoolingModel.City> getCityByName(string name);
        CarpoolingModel.Country getCountryByCity(CarpoolingModel.City city);
        CarpoolingModel.Country getCountryById(int idCountry);
        System.Collections.Generic.List<CarpoolingModel.Country> getCountryByName(string name);
        CarpoolingModel.Place getPlace(int idRoute, bool direction);
        CarpoolingModel.Nation getStateByCountry(CarpoolingModel.Country country);
        CarpoolingModel.Nation getStateById(int id);
        System.Collections.Generic.List<CarpoolingModel.Nation> getStateByName(string name);
        void updatePlace(CarpoolingModel.Place place, CarpoolingModel.Route route);
    }
}
