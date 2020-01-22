FROM microsoft/dotnet:2.2.104-sdk AS build

ARG projname=EmailReplyParser.Lib
ARG key=TODO
ARG packageversion=1.0.1
ARG nugetserver=http://nuget.dev.logicsoftware.net

WORKDIR /src

COPY $projname/$projname.csproj $projname/
#COPY NuGet.config .

RUN dotnet restore $projname/$projname.csproj

COPY . .

WORKDIR /src/$projname
RUN dotnet pack /p:PackageVersion=$packageversion -o packages
RUN dotnet nuget push packages/$projname.$packageversion.nupkg -k $key -s $nugetserver