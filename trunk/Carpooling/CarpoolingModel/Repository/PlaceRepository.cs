using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CarpoolingDAL;


namespace CarpoolingModel.Repository {
    public class PlaceRepository : CarpoolingModel.Repository.IPlaceRepository{

        private static PlaceRepository instanca = null;
        private static CarpoolingDBADataContext db = new CarpoolingDBADataContext();
        private PlaceRepository() {

        }
        public static PlaceRepository getInstanca() {
            if (instanca == null) {
                instanca = new PlaceRepository();
            }
            return instanca;
        }

        public Nation getStateByCountry(Country country) {
            CarpoolingDAL.Coutry co = new CarpoolingDAL.Coutry();
            CarpoolingDAL.State st = new CarpoolingDAL.State();
            try {
                var query = db.Coutries.Where(o => o.idCoutry == country.Id).First();
                co = query as CarpoolingDAL.Coutry;
                var query2 = db.States.Where(o => o.idState == co.idCoutry).First();
                st = query2 as CarpoolingDAL.State;
            } catch (Exception) {
                st = null;
            }

            return RepositoryUtility.createNationFromDALState(st);
        }

        public Country getCountryByCity(City city) {
            CarpoolingDAL.City ci = new CarpoolingDAL.City();
            CarpoolingDAL.Coutry co = new CarpoolingDAL.Coutry();
            try {
                var query = db.Cities.Where(o => o.idCity == city.Id).First();
                ci = query as CarpoolingDAL.City;
                var query2 = db.Coutries.Where(o => o.idCoutry == ci.idCoutry).First();
                co = query2 as CarpoolingDAL.Coutry;
            } catch (Exception) {
                co = null;
            }

            return RepositoryUtility.createCoutryFromDALCoutry(co);
        }

        public List<Country> getAllCountriesOfState(Nation state) {
            List<Country> listCo = new List<Country>();
            var coutries = db.Coutries.Where(s => s.idState == state.Id);

            foreach (CarpoolingDAL.Coutry mem in coutries) {
                listCo.Add(RepositoryUtility.createCoutryFromDALCoutry(mem as CarpoolingDAL.Coutry));
            }
            return listCo;
        }

        public List<Nation> getAllStates() {
            List<Nation> allNations = new List<Nation>();
            foreach (CarpoolingDAL.State o in db.States) {
                allNations.Add(RepositoryUtility.createNationFromDALState(o));
            }
            return allNations;
        }

        public List<City> getAllTownsOfCountry(Country country) {
            List<City> listCity = new List<City>();
            var cities = db.Cities.Where(s => s.idCoutry == country.Id);

            foreach (CarpoolingDAL.City mem in cities) {
                listCity.Add(RepositoryUtility.createCityFromDALCity(mem as CarpoolingDAL.City));
            }
            return listCity;
        }

        public Nation getStateById(int id) {
            CarpoolingDAL.State st = new CarpoolingDAL.State();
            try {
                var query = db.States.Where(o => o.idState == id).First();
                st = query as CarpoolingDAL.State;
            } catch (Exception) {
                st = null;
            }

            return RepositoryUtility.createNationFromDALState(st);
        }

        public Country getCountryById(int idCountry) {
            CarpoolingDAL.Coutry co = new CarpoolingDAL.Coutry();
            try {
                var query = db.Coutries.Where(o => o.idCoutry == idCountry).First();
                co = query as CarpoolingDAL.Coutry;
            } catch (Exception) {
                co = null;
            }

            return RepositoryUtility.createCoutryFromDALCoutry(co);
        }

        public List<Country> getCountryByName(string name) {
            List<Country> listCo = new List<Country>();
            var coutries = db.Coutries.Where(s => s.name == name);

            foreach (CarpoolingDAL.Coutry mem in coutries) {
                listCo.Add(RepositoryUtility.createCoutryFromDALCoutry(mem as CarpoolingDAL.Coutry));
            }
            return listCo;
        }

        public List<Nation> getStateByName(string name) {
            List<Nation> listSt = new List<Nation>();
            var states = db.States.Where(s => s.name == name);

            foreach (CarpoolingDAL.State mem in states) {
                listSt.Add(RepositoryUtility.createNationFromDALState(mem as CarpoolingDAL.State));
            }
            return listSt;
        }

        public City getCityById(int id) {
            CarpoolingDAL.City ci = new CarpoolingDAL.City();
            try {
                var query = db.Cities.Where(o => o.idCity == id).First();
                ci = query as CarpoolingDAL.City;
            } catch (Exception) {
                ci = null;
            }

            return RepositoryUtility.createCityFromDALCity(ci);
        }

        public List<City> getCityByName(string name) {
            List<City> listCi = new List<City>();
            var cities = db.Cities.Where(s => s.name == name);

            foreach (CarpoolingDAL.City mem in cities) {
                listCi.Add(RepositoryUtility.createCityFromDALCity(mem as CarpoolingDAL.City));
            }
            return listCi;
        }

        public Place getPlace(int idRoute, bool direction)
        {
            CarpoolingDAL.StartFinish sf = new CarpoolingDAL.StartFinish();
            Place p = new Place();
            try {
                var query = db.StartFinishes.Where(o => o.idRoute == idRoute && o.direction == direction).First();
                sf = query as CarpoolingDAL.StartFinish;
                p.Address = sf.address;
                p.InOrOut = sf.direction;
                p.City = getCityById(sf.idCity);
                p.Country = getCountryByCity(p.City);
                p.State = getStateByCountry(p.Country);
            } catch (Exception) {
                p = null;
            }
            return p;
        }

        public void addPlace(Place place, Route route)
        {
            try {
                db.StartFinishes.InsertOnSubmit(RepositoryUtility.createDALStartFinishFromPlace(place, route));
                db.SubmitChanges();
            } catch (Exception) {
                //TODO saznaj koje su iznimke
                //iznimka se generira ako se narusi bilo koje pravilo vezano uz primary key ili foreign key. Znači, iznimka se 
                //generira ako se pokuša dodati osoba koja ima JMBAG koji koristi neka druga osoba, zatim ako se pod osoba.sifUloga 
                //stavi neki broj kojeg nema u tablici Uloga, itd..
                //return false;
            }
            //return true;
        }

        public void updatePlace(Place place, Route route)
        {
            try {
                RouteRepository rr = RouteRepository.getInstanca();
                ResourceRepository rer = ResourceRepository.getInstanca();
                CarpoolingDAL.StartFinish oldOne = db.StartFinishes.Single(o => o.idRoute == route.Id && o.direction == place.InOrOut);
                oldOne.address = place.Address;
                oldOne.idCity = place.City.Id;
                db.SubmitChanges();
            } catch (Exception) {
                //return false;
            }

            //return true;
        }

    }
}
