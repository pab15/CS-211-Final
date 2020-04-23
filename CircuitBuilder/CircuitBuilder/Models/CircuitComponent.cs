using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CircuitBuilder.Models
{
    public class CircuitComponent
    {
        private string componentType;
        private List<int> componentPosition;

        public CircuitComponent()
        {
            this.componentType = null;
            this.componentPosition = null;
        }
        public CircuitComponent(string componentType, List<int> componentPosition)
        {
            this.componentType = componentType;
            this.componentPosition = componentPosition;
        }
        public void setComponentType(string componentType)
        {
            this.componentType = componentType;
        }
        public string getComponentType()
        {
            return this.componentType;
        }
        public void setComponentPosition(List<int> componentPosition)
        {
            this.componentPosition = componentPosition;
        }
        public List<int> getComponentPosition()
        {
            return this.componentPosition;
        }
    }
}