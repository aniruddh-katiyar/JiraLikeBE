FROM ollama/ollama:latest

WORKDIR /app
EXPOSE 8080

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        wget \
        ca-certificates \
        sqlite3 \
        libsqlite3-dev && \
    wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y aspnetcore-runtime-8.0 && \
    rm -rf /var/lib/apt/lists/*

COPY ./JiraLike.Api/bin/Release/net8.0/publish/ .

ENV ASPNETCORE_ENVIRONMENT=Production
RUN mkdir -p /app/data

ENTRYPOINT ["/bin/sh", "-c"]
CMD ["ollama serve & sleep 10 && ollama pull tinyllama && exec dotnet JiraLike.Api.dll"]
