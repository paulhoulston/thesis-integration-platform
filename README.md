# thesis-integration-platform
An example subscriber for Thesis' Integration Platform using a .Net (core) WinForms application.

To use, set the following Windows environment variables:-

	- Elements-Service-Bus-Connection-String: Connection string to Azure Service Bus
	- Elements-Service-Bus-Topic: Azure Service Bus topic which data is published on to
	- Elements-Service-Bus-Subscription: Subscription name for the Azure Service Bus topic
	- Elements-SMTP-User: User for O365 SMTP client, e.g. joe.blogs@somedomain.com
	- Elements-SMTP-Password: Password for O365 SMTP client
