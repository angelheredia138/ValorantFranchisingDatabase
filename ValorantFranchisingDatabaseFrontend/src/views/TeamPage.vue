<template>
  <div class="team-page">
    <h1 class="team-title">Team Roster</h1>

    <!-- Back to Home Button -->
    <router-link to="/" class="back-button">Back to Home</router-link>
    <button @click="goBack" class="back-button">Back</button>

    <!-- Loading and Error Messages -->
    <div v-if="loading" class="loading">Loading players...</div>
    <div v-else-if="error" class="error">{{ error }}</div>

    <div class="players-container">
      <router-link
        v-for="player in players"
        :key="player.id"
        :to="{ name: 'player', params: { id: player.id } }"
        class="player-card-link"
      >
        <div class="player-card">
          <!-- Player Profile Image or Placeholder -->
          <div class="player-profile-wrapper">
            <img
              v-if="
                player.profileImageUrl &&
                !player.profileImageUrl.endsWith('sil.png')
              "
              :src="player.profileImageUrl"
              :alt="player.name"
              class="player-profile"
            />
            <img
              v-else
              :src="playerPlaceholder"
              alt="Player silhouette"
              class="player-silhouette"
            />
          </div>

          <!-- Player Name and Country -->
          <div class="player-info">
            <img
              v-if="player.country"
              :src="`https://flagcdn.com/w40/${player.country.toLowerCase()}.png`"
              :alt="player.country"
              class="flag-icon"
            />
            <h3 class="player-name">{{ player.name }}</h3>
          </div>

          <!-- Additional Info -->
          <p class="player-realname" v-if="player.realName">
            Real Name: {{ player.realName }}
          </p>
          <p class="player-role" v-if="player.roleDescription">
            Role: {{ player.roleDescription }}
          </p>
          <p class="player-empty-role" v-else>
            Role: {{ player.roleDescription }}
          </p>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import playerPlaceholder from "../assets/player-placeholder.png";

export default {
  name: "TeamPage",
  props: ["id"], // Team ID passed from the route
  data() {
    return {
      players: [],
      playerPlaceholder,
      loading: true,
      error: null,
    };
  },
  methods: {
    async fetchPlayers() {
      try {
        const response = await axios.get(
          `http://localhost:5128/api/Valorant/players/${this.id}`
        );
        this.players = response.data;
      } catch (error) {
        this.error = "Failed to load players for the team.";
      } finally {
        this.loading = false;
      }
    },
    goBack() {
      this.$router.back(); // Navigate back to the previous page
    },
  },
  async created() {
    this.loading = true;
    await this.fetchPlayers();
  },
};
</script>

<style scoped>
.team-page {
  text-align: center;
  padding: 2rem;
  font-family: Arial, sans-serif;
  color: #f4f4f4;
  min-height: 100vh;
}

.team-title {
  font-size: 2.5rem;
  color: #ff4655;
  margin-bottom: 2rem;
}

.players-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 1.5rem;
}

.player-card {
  background-color: #3a3a4d;
  padding: 1rem;
  border-radius: 8px;
  width: 220px;
  text-align: center;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.player-card:hover {
  transform: scale(1.05);
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.5);
}

.player-profile-wrapper {
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 120px; /* Slightly larger container for better centering */
  height: 120px;
  border-radius: 50%;
  background-color: #444;
  margin: 0 auto 1rem; /* Center horizontally and add bottom margin */
}

.player-profile,
.player-silhouette {
  width: 100%;
  height: 100%;
  border-radius: 50%;
  object-fit: cover;
  display: block; /* Ensures proper centering inside the container */
}

.player-info {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 0.5rem;
  margin-bottom: 0.5rem;
}

.flag-icon {
  width: 20px;
  height: 15px;
  border-radius: 2px;
  object-fit: cover;
}

.player-name {
  font-size: 1.2rem;
  font-weight: bold;
  color: #ffffff;
}

.player-role,
.player-realname {
  font-size: 0.9rem;
  color: #cccccc;
}
.player-empty-role {
  font-size: 0.9rem;
  color: #3a3a4d;
}
.player-card-link {
  text-decoration: none;
  color: inherit;
  display: inline-block;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.player-card-link:hover {
  transform: scale(1.05);
}

.loading {
  font-size: 1.5rem;
  color: #ffb800;
}

.error {
  font-size: 1.2rem;
  color: #ff4655;
}

.back-button {
  display: inline-block;
  margin: 1rem;
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
</style>
