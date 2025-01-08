#!/bin/bash

DOCKERFILE="docker-compose.yml"

echo "1. Build and run"
echo "2. Build"
echo "3. Run"
echo "4. Stop"
echo "5. Remove"
echo "6. View containers"
echo "7. Clean "
echo "8. Prune volumes"

read -rp "Enter option: " option

cd ../infrastructure || exit

if [ "$option" -eq 1  ]; then
  docker-compose -f $DOCKERFILE up --build -d
elif [ "$option" -eq 2 ]; then
  docker-compose -f $DOCKERFILE build
elif [ "$option" -eq 3 ]; then
  docker-compose -f $DOCKERFILE up -d
elif [ "$option" -eq 4 ]; then
  docker-compose -f $DOCKERFILE stop
elif [ "$option" -eq 5 ]; then
  docker-compose -f $DOCKERFILE down
elif [ "$option" -eq 6 ]; then
  docker-compose -f $DOCKERFILE ps
elif [ "$option" -eq 7 ]; then
  docker system prune --all
elif [ "$option" -eq 8 ]; then
  docker volume prune --filter all=1
else
  echo "Invalid option"
  exit
fi