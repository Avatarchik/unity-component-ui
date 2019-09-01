﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Engine
{
    public class ConnectedSystemRegistry
    {
        private Dictionary<string, ConnectedSystem> systems;

        private static ConnectedSystemRegistry instance;

        public static ConnectedSystemRegistry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectedSystemRegistry();
                }

                return instance;
            }
        }

        private ConnectedSystemRegistry()
        {
            systems = new Dictionary<string, ConnectedSystem>();
        }

        public void Register(string name, ConnectedSystem system)
        {
            systems.Add(name, system);
        }

        public ConnectedSystem Get(string name)
        {
            if (systems.ContainsKey(name))
            {
                return systems[name];
            }

            return null;
        }
    }
}
