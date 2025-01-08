<template>
  <div class="player-page">
    <button @click="goBack" class="back-button">Back</button>

    <!-- Player Overview Section -->
    <div class="player-overview">
      <div class="player-image-wrapper">
        <img
          v-if="playerData.playerImage"
          :src="playerData.playerImage"
          :alt="playerData.playerRealName"
          class="player-profile"
        />
        <img
          v-else
          src="../assets/player-placeholder.png"
          alt="Player silhouette"
          class="player-silhouette"
        />
      </div>
      <div class="player-details">
        <h1 class="player-username">{{ playerData.username }}</h1>
        <p class="player-realname">{{ playerData.playerRealName }}</p>
        <p v-if="playerData.country" class="player-country">
          <img
            :src="`https://flagcdn.com/w40/${playerData.country.toLowerCase()}.png`"
            :alt="playerData.country"
            class="country-flag"
          />
          {{ playerData.country }}
        </p>
        <h2 class="current-team" v-if="playerData.currentTeam">
          Current Team: {{ playerData.currentTeam }}
          <div v-if="playerData.currentTeamImage" class="team-logo-wrapper">
            <img
              :src="playerData.currentTeamImage"
              alt="Current Team Logo"
              class="team-logo"
            />
          </div>
        </h2>
      </div>
    </div>

    <!-- Social Media Section -->
    <div
      class="details-card"
      v-if="
        playerData.socialMediaHandles && playerData.socialMediaHandles.length
      "
    >
      <h3>Social Media</h3>
      <ul class="horizontal-list">
        <li
          v-for="(handle, index) in playerData.socialMediaHandles"
          :key="index"
        >
          <a :href="handle" target="_blank" rel="noopener noreferrer">{{
            handle
          }}</a>
        </li>
      </ul>
    </div>

    <!-- Past Teams Section -->
    <div
      class="details-card"
      v-if="playerData.pastTeams && playerData.pastTeams.length"
    >
      <h3>Past Teams</h3>
      <ul class="horizontal-list">
        <li v-for="(team, index) in playerData.pastTeams" :key="index">
          <img
            v-if="playerData.pastTeamImages[index]"
            :src="playerData.pastTeamImages[index]"
            alt="Past Team Logo"
            class="team-logo"
          />
          {{ team }}
        </li>
      </ul>
    </div>

    <!-- Last Matches Section -->
    <div
      class="details-card"
      v-if="playerData.lastMatches && playerData.lastMatches.length"
    >
      <h3>Last Matches</h3>
      <ul class="horizontal-list">
        <li v-for="(match, index) in playerData.lastMatches" :key="index">
          <img
            v-if="match.teamImage"
            :src="match.teamImage"
            alt="Team Image"
            class="match-logo"
          />
          vs
          <img
            v-if="match.opponentImage"
            :src="match.opponentImage"
            alt="Opponent Image"
            class="match-logo"
          />
          {{ match.eventName }} - {{ match.result }} ({{ match.date.trim() }})
        </li>
      </ul>
    </div>

    <!-- Agent Info Section -->
    <div
      class="details-card"
      v-if="playerData.topAgents && playerData.topAgents.length"
    >
      <h3>Top Agents</h3>
      <ul class="horizontal-list">
        <li v-for="(agent, index) in playerData.topAgents" :key="index">
          <img
            v-if="agent.agentImage"
            :src="agent.agentImage"
            alt="Agent Image"
            class="agent-image"
          />
          <strong>{{ agent.agentName }}</strong> ({{ agent.usage }}) - ACS:
          {{ agent.acs }}
        </li>
      </ul>
    </div>

    <!-- Total Winnings Section -->
    <div class="details-card">
      <h3>Total Winnings</h3>
      <p>{{ playerData.totalWinnings }}</p>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "PlayerPage",
  data() {
    return {
      playerData: {}, // Initialize as an empty object to avoid errors during rendering
      loading: true,
      error: null,
    };
  },
  methods: {
    goBack() {
      this.$router.back();
    },
    async fetchPlayerData(playerId) {
      try {
        const response = await axios.get(
          `http://localhost:5128/api/Valorant/player-stats/${playerId}`
        );
        console.log(response.data);
        this.playerData = response.data;
        console.log(this.playerData);
      } catch (error) {
        console.error("API Error:", error);
        this.error = "Failed to load player details.";
      } finally {
        this.loading = false;
      }
    },
  },
  async created() {
    const playerId = this.$route.params.id;
    this.loading = true;
    await this.fetchPlayerData(playerId);
  },
};
</script>

<style scoped>
.player-page {
  padding: 2rem;
  font-family: Arial, sans-serif;
  color: #f4f4f4;
}

.back-button {
  margin-bottom: 2rem;
  padding: 0.5rem 1rem;
  border: none;
  background-color: #ff4655;
  color: #ffffff;
  border-radius: 5px;
  cursor: pointer;
  font-weight: bold;
  transition: transform 0.2s ease;
}

.back-button:hover {
  background-color: #ff6775;
  transform: scale(1.05);
}

.player-overview {
  display: flex;
  gap: 2rem;
  margin-bottom: 2rem;
}

.player-image-wrapper {
  flex-shrink: 0;
}

.player-profile {
  width: 150px;
  height: 150px;
  border-radius: 50%;
}

.player-username {
  font-size: 2rem;
  font-weight: bold;
  color: #ffffff;
  margin-bottom: 0.5rem;
}

.player-realname {
  font-size: 1.2rem;
  color: #cccccc;
}

.player-country {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.country-flag {
  width: 30px;
  height: 20px;
}

.current-team {
  font-size: 1.2rem;
}

.team-logo-wrapper {
  background: linear-gradient(45deg, #ff4655, #7b5cff);
  padding: 5px;
  display: inline-block;
  border-radius: 8px;
}

.team-logo {
  width: 40px;
  height: 40px;
  border-radius: 5px;
}

.details-card {
  background-color: #3a3a4d;
  padding: 1.5rem;
  border-radius: 10px;
  margin-bottom: 1rem;
  text-align: left;
}

.details-card h3 {
  color: #ff4655;
}

.horizontal-list {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
}

.match-logo,
.agent-image {
  width: 40px;
  height: 40px;
  border-radius: 5px;
}
</style>
