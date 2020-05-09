#!/usr/bin/env bash

# http://redsymbol.net/articles/unofficial-bash-strict-mode
set -euo pipefail

until /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P $SA_PASSWORD -l 60 -i /app/setup.sql & /opt/mssql/bin/sqlservr; do
    echo "WARN: SOMETHING IS WRONG!"
done
