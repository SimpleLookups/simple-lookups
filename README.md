Simple Lookups
===

---

Simple Lookups is an incredibly simple database library for .NET and SQL Server that manages all of your "type" lookups. 

For example, if you have a "Provider" table in your database, well, you probably have a ProviderType table as well. Most of these type tables will have the same five columns - ID, Name, Description, Code, and an Active flag. As long as your tables fit that model, Simple Lookups will do all the CRUD work.

All you have to do is create a class called ProviderType that inherits from SimpleLookups.Lookup (and really has no further implementation), and then use a generic LookupManager<ProviderType> to do those CRUD operations.

SimpleLookups will also cache lookup values in memory so that you can save database hits and get values very quickly.

For more information, see the website [simplelookups.com](simplelookups.com).


Feature request?
---
Do you have a feature request? Send an email to support@simplelookups.com.

Running The Tests
---
If you want to run the tests on your machine, take a look at the README in the _TestEnvSetup folder.

Contributing
---
Do you want to add a feature to Simple Lookups? Go right ahead! And, if we like it, it might end up in the core product!

How to get started:

1. Create a fork of simple-lookups.
1. Make all of the changes that you wish to make.
1. Create a pull request. We'll take a look and see if it fits into our vision for Simple Lookups.

License
---
SimpleLookups is open source software, licensed under the terms of BSD license. 
See LICENSE for details.
