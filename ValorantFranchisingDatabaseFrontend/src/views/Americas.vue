<template>
  <div class="americas-page">
    <h1>Americas Region</h1>
    <p>Welcome to the Americas region page!</p>

    <div v-if="loading" class="loading">Loading teams...</div>
    <div v-else-if="error" class="error">{{ error }}</div>
    <div v-else class="teams-container">
      <div class="team-card" v-for="team in teams" :key="team.id">
        <img :src="team.logoUrl" :alt="team.name" class="team-logo" />
        <h2 class="team-name">{{ team.name }}</h2>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Americas",
  data() {
    return {
      teams: [],
      loading: true,
      error: null,
    };
  },
  async created() {
    try {
      const response = await axios.get(
        "http://localhost:5128/api/Valorant/teams/americas"
      );
      console.log("API Response:", response.data); // Log the response
      this.teams = response.data;
    } catch (err) {
      console.error("API Error:", err); // Log the error
      this.error = "Failed to load teams. Please try again later.";
    } finally {
      this.loading = false;
    }
  },
};
</script>

<style scoped>
.americas-page {
  text-align: center;
  padding: 2rem;
  font-family: Arial, sans-serif;
  color: #f4f4f4;
  min-height: 100vh;
}

.americas-page h1 {
  font-size: 2.5rem;
  color: #ff4655;
}

.americas-page p {
  font-size: 1.2rem;
  margin-bottom: 2rem;
  color: #e0e0e0;
}

.loading {
  font-size: 1.5rem;
  color: #ffb800;
}

.error {
  font-size: 1.2rem;
  color: #ff4655;
}

.teams-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 1.5rem;
}

.team-card {
  background-color: #3a3a4d; /* Lighter dark background */
  padding: 1rem;
  border-radius: 8px;
  width: 200px;
  text-align: center;
  position: relative; /* Needed for overlay */
  overflow: hidden; /* Ensures the overlay doesn’t spill out */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); /* Softer shadow */
  transition: transform 0.3s ease, box-shadow 0.3s ease,
    background-color 0.3s ease;
}

.team-card::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(
    0deg,
    rgba(255, 255, 255, 0.3) 0%,
    rgba(255, 255, 255, 0.001) 100%
  );
  z-index: 0; /* Ensure it’s behind the content */
}

.team-card:hover {
  transform: scale(1.05);
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.3); /* Slightly stronger hover shadow */
  background-color: #4a4a5e; /* Even lighter on hover */
}

.team-logo {
  position: relative; /* Raise above the overlay */
  z-index: 1;
  width: 100px;
  height: 100px;
  object-fit: contain;
  margin-bottom: 1rem;
}

.team-name {
  font-size: 1.2rem;
  font-weight: bold;
  color: #ffffff;
}
</style>
