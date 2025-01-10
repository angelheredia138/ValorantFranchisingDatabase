# VALORANT Franchising Database

The **VALORANT Franchising Database** is a web application designed to provide a centralized hub of information about the franchised teams, players, and regions participating in VALORANT esports. The frontend is built using **Vue.js** and deployed on **GitHub Pages**, while the backend API is custom-built using **.NET 8** and hosted on **Azure**. This project aims to deliver a clean and engaging user experience for exploring team rosters, player statistics, and regional details.

## Features

- **Region Pages**: Explore teams in different regions, including EMEA, Americas, Pacific, and China.
- **Team Pages**: View detailed team rosters, including player names, roles, and associated social media links.
- **Player Pages**: Dive into individual player profiles with comprehensive stats, past teams, recent matches, and top agents.

---

## Backend API

This project uses a custom-built **VALORANT Franchising API**, specifically developed for this web app. The API provides endpoints to fetch data for:

- Teams in each region
- Players on specific teams
- Individual player statistics, past teams, and matches

### API Features

- **Franchising Data**: Aggregates and structures data for VALORANT teams and players.
- **Caching**: Implements caching for improved performance and reduced redundant requests.
- **Endpoints**:
  - `/api/Valorant/teams/{region}`: Returns team details for a given region.
  - `/api/Valorant/players/{teamId}`: Returns players belonging to a team.
  - `/api/Valorant/player-stats/{playerId}`: Returns comprehensive details about a specific player.

The API is deployed on **Azure** for high availability and performance. Its development was tailored exclusively for this project, ensuring seamless integration with the frontend.

---

## Tech Stack

### Frontend

- **Framework**: Vue.js
- **Build Tool**: Vite
- **Deployment**: GitHub Pages

### Backend

- **Framework**: .NET 8
- **Hosting**: Azure App Service
- **Data Integration**: Custom scraping logic for sourcing VALORANT esports data

---

## Deployment and Hosting

### Frontend

- **Deployed on GitHub Pages**:
  - Base URL: [https://angel-heredia.com/vlr-franchising-database/](https://angel-heredia.com/vlr-franchising-database/)
- **Build Command**:
  ```bash
  npm run build
  npm run deploy
  ```

### Backend

- **Hosted on Azure App Service**:
  - Base URL: [https://vlr-franchising-database-backend-a5cgguczc6fna4hj.canadacentral-01.azurewebsites.net/api](https://vlr-franchising-database-backend-a5cgguczc6fna4hj.canadacentral-01.azurewebsites.net/api)
- **Publishing Command**:
  ```bash
  dotnet publish -c Release -o ./publish
  ```

---

## Future Enhancements

- **User Accounts**: Add login and personalized team/player tracking.
- **Live Data Updates**: Integrate live match stats via official APIs (if available).
- **Search Functionality**: Allow users to search for players, teams, and regions directly.

---

## Acknowledgments

This project is developed by **Angel Heredia** as a comprehensive exploration of both frontend and backend development in the esports domain. All data is sourced from public information and is not affiliated with Riot Games or VALORANT.

Feel free to contribute to the project or provide feedback via the repository issues tab!
