using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CircuitBuilder.Models
{
    public class CircuitGraph
    {
        // Component Property:
        // First --> Position of Component
        // Second --> Component Object
        // Dictionary Allows Us to Quickly Check if a Position is Taken.
        private Dictionary<List<int>, CircuitComponent> components { get; set; }

        // Connection Property:
        // First --> Circuit Component
        // Second --> All Adjacent Circuit Components
        private Dictionary<CircuitComponent, List<CircuitComponent>> connections { get; set; }


        public void addComponent(string componentType, List<int> componentPosition)
        {
            if (this.components.ContainsKey(componentPosition))
            {
                this.components[componentPosition] = new CircuitComponent(componentType, componentPosition);
            }
            else
            {
                this.components.Add(componentPosition, new CircuitComponent(componentType, componentPosition));
            }
        }
        public void removeComponent(List<int> componentPosition)
        {
            if (this.components.ContainsKey(componentPosition))
            {
                this.components.Remove(componentPosition);
            }
        }
    }
}