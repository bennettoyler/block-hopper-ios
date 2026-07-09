# Block Hopper!

A hypercasual platformer developed for iOS. Built using Unity and C#, this was my first end-to-end mobile game development and publishing experience. 

## Gameplay & Features

Block Hopper! is designed for quick, engaging play sessions with increasing difficulty. 

*   **Procedural Level Progression:** Implemented algorithms to dynamically generate level layouts, ensuring a unique player experience during every run.
*   **Integrated Systems:** Custom-built UI and audio managers to handle game states, menus, and sound effects.
*   **Ad Monetization:** Successfully integrated mobile ad networks for revenue generation within the core game loop.
*   **Mobile-First Controls:** Optimized touch inputs for seamless platforming mechanics on iOS devices.

## App Store Page

Find the game listing and screenshots here:
https://apps.apple.com/in/app/block-hopper/id6444784717

## Developer Retrospective (2022 vs. Today)

I developed this game entirely from scratch between August and December of 2022. As my first major software project, the primary goal was to learn the complete lifecycle of a mobile application—from opening an empty Unity project to navigating the strict Apple App Store review process.

Looking back at this codebase with the software engineering fundamentals I have developed since, there are several architectural changes I would make if I were building this today:

1.  **Separation of Concerns:** Much of the UI and Audio logic is tightly coupled with the core gameplay loop. Today, I would utilize an Event-Driven Architecture (like the Observer pattern) to decouple these systems, making the codebase more modular and testable.
2.  **Memory Management:** Hypercasual games require strict performance optimization. Instead of heavily relying on `Instantiate()` and `Destroy()` for platform generation (which causes garbage collection spikes), I would implement an **Object Pooling** system to reuse memory allocations efficiently.
3.  **State Management:** I would refactor the monolithic game manager into a finite state machine (FSM) to cleanly handle transitions between the Main Menu, Active Gameplay, Paused, and Game Over states.

While the code reflects where I was as a developer in 2022, I keep this repository public as a testament to my ability to self-teach, ship products, and continuously improve my engineering standards.
