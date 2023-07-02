using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;

namespace StateMachine.Scripts
{
    public class StateMachine <TInitializer>
    {
        private IState<TInitializer> _currentState;
        
        private readonly Dictionary<Type, IState<TInitializer>> _states;

        private bool _isTicking;

        public StateMachine(params IState<TInitializer>[] states)
        {
            _states = new Dictionary<Type, IState<TInitializer>>(states.Length);

            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public void SwitchState<TState>() where TState : IState<TInitializer>
        {
            TryExitPreviousState<TState>();

            GetNewState<TState>();

            TryEnterNewState<TState>();

            TryTickNewState<TState>();
        }

        private void TryExitPreviousState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is IExitable exitable)
            {
                exitable.OnExit();
            }
        }

        private void GetNewState<TState>() where TState : IState<TInitializer>
        {
            var newState = GetState<TState>();
            _currentState = newState;
        }

        private TState GetState<TState>() where TState : IState<TInitializer>
        {
            return (TState)_states[typeof(TState)];
        }
        
        private void TryEnterNewState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is IEnterable enterable) enterable.OnEnter();
        }

        private void TryTickNewState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is ITickable tickable)
            {
                _isTicking = true;
                StartTick(tickable);
            }
            else _isTicking = false;
        }

        private async void StartTick(ITickable tickable)
        {
            while (_isTicking)
            {
                tickable.Tick();
                await Task.Yield();
            }
        }
    }
}