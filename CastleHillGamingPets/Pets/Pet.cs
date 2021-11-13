﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CastleHillGamingPets.Pets
{
    [Serializable]
    [XmlInclude(typeof(Cat))]
    [XmlInclude(typeof(Dog))]
    [XmlInclude(typeof(Fish))]
    [XmlInclude(typeof(Plant))]
    public abstract class Pet
    {
        public string Name { get; set; }

        protected int _happiness;
        public int Happiness 
        { 
            get
            {
                return _happiness;
            }
            set
            {
                _happiness = value;
                if (_happiness > MaxHappiness)
                {
                    _happiness = MaxHappiness;
                }
            }
        }
        public int MaxHappiness { get; set; }

        public int Hunger { get; set; }
        
        /// <summary>
        /// I named this HungerThreshold instead of MaxHunger because the design doc makes it sound like Hunger is allowed to go over MaxHunger.
        /// </summary>
        public int HungerThreshold { get; set; }

        protected abstract long TimerInterval { get; }
        protected long TimeSinceLastDecay;

        public abstract string GetPetType();
        public abstract void Eat(eFood food);
        public abstract void Interact(eInteraction interaction);
        public virtual void TimePasses(long minutes)
        {
            TimeSinceLastDecay += minutes;
            bool changed = false;
            while (TimeSinceLastDecay >= TimerInterval)
            {
                TimeSinceLastDecay -= TimerInterval;
                Decay();
                changed = true;
            }

            if (changed)
            {
                Console.WriteLine($"{GetPetType()} {Name} is getting hungry. Happiness {Happiness} and Hunger {Hunger}");
            }
        }

        protected virtual void Decay()
        {
            Hunger++;
            Happiness--;
        }
    }
}