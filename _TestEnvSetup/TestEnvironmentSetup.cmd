sqllocaldb create SL
sqllocaldb start SL
sqlcmd -S "(localdb)\SL" -i dbsetup.sql

pause