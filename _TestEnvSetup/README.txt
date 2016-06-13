SimpleLookups Tests
===================

The test projects use LocalDB as a datastore. 

In my test environment, I have Visual Studio 2015 Community and SQL LocalDB 2014. I suggest using the same for consistency.

Here are the 1-step instructions to run my tests for SimpleLookups.

Environment Setup:
-------------
1. Run TestEnvironmentSetup.cmd.

Environment Teardown:
-------------
1. Run TestEnvironmentTeardown.cmd.

What they do:
-------------
A new local db instance is created called "SL" and a database is created called "SimpleLookups". 
In this database, there are three tables created and populated with data. These tables are used
by my tests.