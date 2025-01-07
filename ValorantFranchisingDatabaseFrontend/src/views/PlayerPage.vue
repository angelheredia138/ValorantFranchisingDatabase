<template>
  <div class="player-page">
    <button @click="goBack" class="back-button">Back</button>
    <h1>Player Details</h1>
    <div v-if="loading" class="loading">Loading player details...</div>
    <div v-else-if="error" class="error">{{ error }}</div>
    <div v-else>
      <!-- Player Profile -->
      <div class="player-profile-wrapper">
        <img
          v-if="
            playerData.playerImage &&
            !playerData.playerImage.endsWith('sil.png')
          "
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
      <h2>{{ playerData.playerRealName }}</h2>
      <p v-if="playerData.country">
        <strong>Country:</strong> {{ playerData.country }}
      </p>
      <p v-if="playerData.currentTeam">
        <strong>Current Team:</strong> {{ playerData.currentTeam }}
      </p>
      <p v-if="playerData.totalWinnings">
        <strong>Total Winnings:</strong> {{ playerData.totalWinnings }}
      </p>

      <!-- Past Teams -->
      <div v-if="playerData.pastTeams && playerData.pastTeams.length">
        <h3>Past Teams</h3>
        <ul>
          <li v-for="(team, index) in playerData.pastTeams" :key="index">
            {{ team }}
          </li>
        </ul>
      </div>

      <!-- Social Media Handles -->
      <div
        v-if="
          playerData.socialMediaHandles && playerData.socialMediaHandles.length
        "
      >
        <h3>Social Media</h3>
        <ul>
          <li
            v-for="(handle, index) in playerData.socialMediaHandles"
            :key="index"
          >
            <a :href="handle" target="_blank" rel="noopener noreferrer">
              {{ handle }}
            </a>
          </li>
        </ul>
      </div>

      <!-- Last Matches -->
      <div v-if="playerData.lastMatches && playerData.lastMatches.length">
        <h3>Last Matches</h3>
        <ul>
          <li v-for="(match, index) in playerData.lastMatches" :key="index">
            {{ match.eventName }} - {{ match.result }} ({{ match.date.trim() }})
          </li>
        </ul>
      </div>

      <!-- Top Agents -->
      <div v-if="playerData.topAgents && playerData.topAgents.length">
        <h3>Top Agents</h3>
        <ul>
          <li v-for="(agent, index) in playerData.topAgents" :key="index">
            <strong>{{ agent.agentName }}</strong> ({{ agent.usage }}) - ACS:
            {{ agent.acs }}
          </li>
        </ul>
      </div>
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
        this.playerData = response.data;
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
  text-align: center;
  padding: 2rem;
  font-family: Arial, sans-serif;
  color: #f4f4f4;
}

.back-button {
  display: inline-block;
  margin-bottom: 2rem;
  padding: 0.5rem 1rem;
  border: none;
  background-color: #ff4655;
  color: #ffffff;
  font-size: 1rem;
  text-decoration: none;
  border-radius: 5px;
  text-align: center;
  cursor: pointer;
  font-weight: bold;
  transition: background-color 0.3s ease, transform 0.2s ease;
}

.back-button:hover {
  background-color: #ff6775;
  transform: scale(1.05);
}

.player-profile-wrapper {
  margin-bottom: 1rem;
}

.player-profile {
  width: 150px;
  height: 150px;
  border-radius: 50%;
  object-fit: cover;
  margin-bottom: 1rem;
}

.player-silhouette {
  width: 150px;
  height: 150px;
  border-radius: 50%;
  object-fit: cover;
  margin-bottom: 1rem;
}

.loading,
.error {
  font-size: 1.2rem;
  color: #ff4655;
}
</style>
