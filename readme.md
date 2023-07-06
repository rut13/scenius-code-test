# Scenius Code Test Starter Pack

This repository contains an initial starting point for developing your code-test application, as scaffolding the application is not a part of the challenge. It contains the following directories:

| Directory | Contents |
| --------- | -------- |
| Scenius.CodeTest.Solution | An empty solution with two applications in C# |
| Scenius.CodeTest.UI | A scaffolded Angular project |
| Scenius.CodeTest.Docker | Empty directory to store your Dockerfiles in |

You may decide yourself what to keep. You are not required to use any of these sources in your implementation.

My experience with the assignment:
Brought my own machine because most of the setup was already done on it.
I used PostgreSQL instead of SQL Server because it was less annoying to install on my machine.
Think I covered the musts in the moscow list.
I used RabbitMQ.Client for the message bus, Daniël later told me about MassTransit. Would have probably made an easier solution.
The consumers don't reply with the id of the new entity after they insert it into the database. Don't know if MassTransit has something for this, but I would have used RPC in RabbitMQ instead of 'hoping' the latest added entity is the correct one.
Would have liked to work with Docker, but Angular took me some time to grasp.
The calculations for the calculator are random, but I was more interested in the different aspects of the application, so I skipped it.
Took me some time to adjust to the way Angular works with subscribing to things. Felt like I could have just used promises, but that showed up as deprecated in vscode (was missing some extensions, so could have been that).
Overall fun assignment!
