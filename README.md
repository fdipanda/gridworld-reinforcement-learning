# gridworld-reinforcement-learning
A C# implementation of a Gridworld environment demonstrating Value Iteration and Q-Learning for reinforcement learning.

## Overview
This project implements a **Gridworld environment** in C# to demonstrate key concepts in **Reinforcement Learning**.  
Two approaches are supported:

- **Value Iteration (VI)** for solving Markov Decision Processes using dynamic programming
- **Q-Learning (QL)** for model-free reinforcement learning

The environment includes stochastic transitions, terminal states, walls, and configurable parameters such as noise, reward, discount factor, and exploration rate.

## Algorithms Implemented
- Value Iteration
- Q-Learning (ε-greedy policy with optional decay)

## Technologies Used
- **Language:** C#
- **Paradigm:** Object-Oriented Programming
- **Concepts:** Markov Decision Processes, Reinforcement Learning, Dynamic Programming

## Environment Description
- Grid size: 3 × 4
- Terminal states with rewards +1 and −1
- One wall cell
- Stochastic movement controlled by a noise parameter

## How It Works
1. The user configures environment parameters (noise, reward, discount factor)
2. The user selects an algorithm:
   - Value Iteration computes optimal state values and policies
   - Q-Learning learns action values through episodic interaction
3. Results are printed to the console, showing values and policies

## How to Run
```bash
dotnet run
```

Follow the prompts in the console to select parameters and algorithms.

## Example Output
- Value function values for each state
- Optimal policy directions (↑ ↓ ← →)
- Learned Q-values for each state-action pair

## Academic Context
This project was developed to practice:
- Reinforcement Learning fundamentals
- Markov Decision Processes
- Policy evaluation and improvement
- Model-based vs. model-free learning methods

## Author
Franck Dipanda
