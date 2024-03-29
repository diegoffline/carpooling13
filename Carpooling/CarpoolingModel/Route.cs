﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarpoolingModel.Types;

namespace CarpoolingModel
{
    public class Route
    {
        private int id;
        private Place startingPoint;
        private Place destination;
        private Path path;
        private RouteType type;
        private string name;


        #region Properties
        public int Id {
            get { return id; }
            set { id = value; }
        }
        public Place StartingPoint {
            get { return startingPoint; }
            set { startingPoint = value; }
        }

        public Place Destination {
            get { return destination; }
            set { destination = value; }
        }

        public Path Path {
            get { return path; }
            set { path = value; }
        }

        public RouteType Type {
            get { return type; }
            set { type = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
        #endregion

        public Route() {
            startingPoint = new Place();
            destination = new Place();
            type = new RouteType();
            path = new Path();
        }
        public Route(Place startingPoint) {
            this.startingPoint = startingPoint;
            type = new RouteType();
        }
        public Route(Place startingPoint, Place destination) : this(startingPoint) {
            this.destination = destination;
        }
        public Route(Place startingPoint, Place destination, Path path, RouteType type, string name) : this(startingPoint, destination) {
            this.path = path;
            this.type = type;
            this.name = name;
        }
    }
}
