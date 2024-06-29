# StatlerWaldorfCorp.ES-ProximityMonitor

The Proximity Monitor microservice application listens for ProximityDetected events, picks up the events from Queue, augments them, then sends the events out for dispatch to real-time messaging system.

This example illustrates how to create a monitor microsercie for an event stream emitted by the Event Processor service. Using an integrated Pubnub messaging, real-time update is sent to monitor screens. Here, nearby team members can recieve mobile notifications at the same time.

### Overview
Purpose: Demonstrates monitoring an event stream for proximity detection events.
Use Case: Useful for scenarios where proximity detection is critical and needs to be monitored in real-time. it can send a new message out on a real-time messaging system using PubNub.

### Components
- Messaging Queue - RabbitMQ to pick event from queu
- Http service communication - Team Service to augment events
- Realtime messaging - PubNub tool to push realtime message as soon as available

> message queue vs http vs realtime

#### Key Concepts
- Event Processor: Component responsible for picking event from Message Queue, proceses events and emit as streams.
- Event Stream: The continuous flow of events processed by the event processor.
- Monitor: Listens to the event stream and acts upon ProximityDetected events is emitted as message. It's a JS Web Browser HTML application that listen to push events/messages and displays on screen in realtime.

### Implementation
Design Considerations
- Multiple Event Processors: You can have multiple processors handling different aspects of your application.
- Multiple Outbound Streams: Each processor can emit various event streams.
- Multiple Monitors: Each stream can be monitored by one or more monitors, depending on the application's needs.

1. Define Event Processor: Create processors to handle specific tasks within your domain.
2. Emit Event Streams: Processors emit event streams based on the specific events they handle.
3. Create Monitors: Monitors listen to these streams and take appropriate actions when events are detected.

### Real-time messaging
Real-time messaging tools like PubNub are essential for integrating and coordinating independent components in highly scalable, distributed, and eventually consistent systems, especially when these systems need to interact with client-facing UIs. Because they:
- provide communication channel over a single, long-lived connection allowing server to instantly push updates to connected client through channels.
- are designed to handle precisely this kind of scenario where a service needs to send updates to a client frontend app in real-time. Whether you use WebSockets, SignalR, PubNub, or another tool, you can achieve real-time communication effectively.

    - Reasons why HTTP POST from server to client is not effective
        - POST request from server means client should have endpoint which is definitel NOT ideal
        - HTTP is inherently a request-response protocol
        - Unnecessary network traffic and latency 
            - ...because each request-and-response(though ONLY POST but there's response side-effect) pair involves network round trips
        - Constantly opening and closing connections with HTTP POST requests consumes more server and network resources 
            - ...compared to a single, persistent connection used in protocols designed for real-time communication (e.g., WebSockets).
