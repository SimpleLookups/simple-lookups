sqlcmd -S "(localdb)\SL" -i dbteardown.sql
sqllocaldb stop SL
sqllocaldb delete SL
pause