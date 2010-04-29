using System;
namespace CarpoolingModel {
    interface IPlaceRepository {
        System.Collections.Generic.List<Country> getAllCountriesOfState(Nation state);
        System.Collections.Generic.List<Nation> getAllStates();
        System.Collections.Generic.List<City> getAllTownsOfCountry(Country country);
        City getCityById(int id);
        City getCityByName(string name);
        Country getCountryByCity(City city);
        Country getCountryById(int idCountry);
        System.Collections.Generic.List<Country> getCountryByName(string name);
        Nation getStateByCountry(Country country);
        Nation getStateById(int id);
        System.Collections.Generic.List<Nation> getStateByName(string name);
    }
}
