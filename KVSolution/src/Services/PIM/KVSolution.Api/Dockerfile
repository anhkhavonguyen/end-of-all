#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1803 AS build
WORKDIR /src
COPY ["src/Services/PIM/KVSolution.Api/KVSolution.Api.csproj", "src/Services/PIM/KVSolution.Api/"]
COPY ["src/Services/PIM/Infrastructure/KVSolution.PIM.Infrastructure/KVSolution.PIM.Infrastructure.csproj", "src/Services/PIM/Infrastructure/KVSolution.PIM.Infrastructure/"]
COPY ["src/BuildingBlocks/KVSolution.Common/KVSolution.Common.csproj", "src/BuildingBlocks/KVSolution.Common/"]
COPY ["src/Services/PIM/Core/KVSolution.PIM.Application/KVSolution.PIM.Application.csproj", "src/Services/PIM/Core/KVSolution.PIM.Application/"]
COPY ["src/Services/PIM/Infrastructure/KVSolution.PIM.Persistence/KVSolution.PIM.Persistence.csproj", "src/Services/PIM/Infrastructure/KVSolution.PIM.Persistence/"]
COPY ["src/Services/PIM/Core/KVSolution.PIM.Domain/KVSolution.PIM.Domain.csproj", "src/Services/PIM/Core/KVSolution.PIM.Domain/"]
COPY ["src/Services/PIM/Common/KVSolution.PIM.Common/KVSolution.PIM.Common.csproj", "src/Services/PIM/Common/KVSolution.PIM.Common/"]
RUN dotnet restore "src/Services/PIM/KVSolution.Api/KVSolution.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/PIM/KVSolution.Api"
RUN dotnet build "KVSolution.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KVSolution.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KVSolution.Api.dll"]