using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel {
    public class PlaceRepository : CarpoolingModel.IPlaceRepository {
        private static PlaceRepository instanca = null;

        private PlaceRepository() {

        }
        public static PlaceRepository getInstanca() {
            if (instanca == null) {
                instanca = new PlaceRepository();
            }
            return instanca;
        }

        public Nation getStateByCountry(Country country) {
            throw new System.NotImplementedException();
        }

        public Country getCountryByCity(City city) {
            throw new System.NotImplementedException();
        }

        public List<Country> getAllCountriesOfState(Nation state) {
            throw new System.NotImplementedException();
        }

        public List<Nation> getAllStates() {
            throw new System.NotImplementedException();
        }

        public List<City> getAllTownsOfCountry(Country country) {
            throw new System.NotImplementedException();
        }

        public Nation getStateById(int id) {
            throw new System.NotImplementedException();
        }

        public Country getCountryById(int idCountry) {
            throw new System.NotImplementedException();
        }

        public List<Country> getCountryByName(string name) {
            throw new System.NotImplementedException();
        }

        public List<Nation> getStateByName(string name) {
            throw new System.NotImplementedException();
        }

        public City getCityById(int id) {
            throw new System.NotImplementedException();
        }

        public City getCityByName(string name) {
            throw new System.NotImplementedException();
        }

    }
}
