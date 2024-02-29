using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

// Notes
// 1. What a finite state machine is
// 2. Examples where you'd use one
//     AI, Animation, Game State
// 3. Parts of a State Machine
//     States & Transitions
// 4. States - 3 Parts
//     Tick - Why it's not Update()
//     OnEnter / OnExit (setup & cleanup)
// 5. Transitions
//     Separated from states so they can be re-used
//     Easy transitions from any state

public class StateMachine
{
   private IState _currentState;
   
    //Represents the type of class and their list of transitions
   private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type,List<Transition>>();
    //List of active transitions
   private List<Transition> _currentTransitions = new List<Transition>();
    //Can be any transitions
   private List<Transition> _anyTransitions = new List<Transition>();
   
   private static List<Transition> EmptyTransitions = new List<Transition>(0);

   public void Tick()
   {
      //In this method it first get's the metod needed for the variable called transition.
      //The it checks if that variable is not null
        //If it's not null than it set's it state to the transitions next destination
      //We then tell out currentState to tick
      var transition = GetTransition();
      if (transition != null)
         SetState(transition.To);
      
      _currentState?.Tick();
   }

   public void SetState(IState state)
   {
      //We first check if the state is equal to the current state, if it is then we return(stop running the method)
      //Then we check if we have the previous state, We call onExit to stop the current action
      //Then we set the current state to the new state
      //

      if (state == _currentState)
         return;
      
      _currentState?.OnExit();
      _currentState = state;
      
      _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
      if (_currentTransitions == null)
         _currentTransitions = EmptyTransitions;
      
      _currentState.OnEnter();
   }

   public void AddTransition(IState from, IState to, Func<bool> predicate)
   {
       //We will check if the specified type does not have any transitions
        //We then make a new list of transitions
        //And make the new list of transitions and add it to the dictionary of out current type
       //We then add our new transition to the list
      if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
      {
         transitions = new List<Transition>();
         _transitions[from.GetType()] = transitions;
      }
      
      transitions.Add(new Transition(to, predicate));
   }

   public void AddAnyTransition(IState state, Func<bool> predicate)
   {
        //This will add to the anyTransition list
      _anyTransitions.Add(new Transition(state, predicate));
   }

   private class Transition
   {
      public Func<bool> Condition {get; }
      public IState To { get; }

    
      public Transition(IState to, Func<bool> condition)
      {
         To = to;
         Condition = condition;
      }
   }


   private Transition GetTransition()
   {
    //We have two loops one for any and one for current
        //We will check if the the transition condition is true or false
            //if true return that transition
        //if not return null

      foreach(var transition in _anyTransitions)
         if (transition.Condition())
            return transition;
      
      foreach (var transition in _currentTransitions)
         if (transition.Condition())
            return transition;

      return null;
   }
}