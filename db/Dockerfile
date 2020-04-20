FROM  mcr.microsoft.com/mssql/server:2019-latest

USER root

# Bundle app source
COPY . /app

# Grant permissions for the import-data script to be executable
RUN chmod +x /app/import-data.sh

USER mssql

CMD /bin/bash /app/entrypoint.sh
