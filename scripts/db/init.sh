#!/bin/bash

psql -U $DB_USER -d $DB_NAME -a -f /app/scripts/db/seed.sql