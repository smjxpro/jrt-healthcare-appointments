#!/bin/bash

echo "1. Create Migration"
echo "2. Delete Migration"
echo "3. Update Database"
echo "4. Drop Database"

read -rp "Enter option: " option

if [ "$option" -eq 1 ]; then
  echo "Enter name of Migration"
  read -rp "Enter name: " name
  dotnet ef migrations add $name --startup-project ../src/Healthcare.Appointments.API --project ../src/Healthcare.Appointments.Infrastructure
elif [ "$option" -eq 2 ]; then
  echo "Enter name of Migration"
  read -rp "Enter name: " name
  dotnet ef migrations remove "$name" --startup-project ../src/Healthcare.Appointments.API --project ../src/Healthcare.Appointments.Infrastructure
elif [ "$option" -eq 3 ]; then
  dotnet ef database update --startup-project ../src/Healthcare.Appointments.API --project ../src/Healthcare.Appointments.Infrastructure
elif [ "$option" -eq 4 ]; then
  dotnet ef database drop --startup-project ../src/Healthcare.Appointments.API --project ../src/Healthcare.Appointments.Infrastructure
else
  echo "Invalid option"
  exit
fi
