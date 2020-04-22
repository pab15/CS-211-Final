# CS-211-Final
Final project for CS 211.

### Outline:
---
I have an idea for the final project for this class, but I'm not sure what the difficulty of this project would really be. I want to try to make an ASP.NET MVC project that allows a user to drag and drop circuit components on to a grid, and when submitted, the application would use Prim's or Kruskal's algorithm to find the way to wire the circuit so that the least amount of wire is used.
- Drag and drop electronic components onto a grid
- Have the application draw wires between all potential conections
- Distance is represented by how many squares appart the components are, and maybe what te components are
- Each component is represented by an ComponentNode Object with properties for type of component, and adjacent components
- The grid is represented by a CircuitGraph which has all nodes stored as properties, as well as all possible paths, and weights for those paths stored as well.
- Upon clicking a button, an MCST algorithm runs, and displays the final graph with all the wires/edges displayed.

### Questions:
---
- Is the whole project supposed to be written in C#, or can I use C# and JQuery/Javascript to drag and drop the items?
- Does this sound too difficult to implement?