#!/usr/bin/env bash

# http://redsymbol.net/articles/unofficial-bash-strict-mode
set -euo pipefail

until /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -l 30 -i /app/setup.sql & /opt/mssql/bin/sqlservr; do
    echo "WARN: SOMETHING IS WRONG!"
done
