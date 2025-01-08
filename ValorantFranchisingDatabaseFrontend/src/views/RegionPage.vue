<template>
  <div class="region-page">
    <div v-if="loading">
      <Loading />
    </div>
    <div v-else>
      <!-- Header Section -->
      <div class="header">
        <img :src="regionLogo" :alt="regionName" class="header-logo" />
        <h1 class="header-title valorant-font">
          VCT {{ regionName.toUpperCase() }}
        </h1>
      </div>

      <!-- Back to Home Button -->
      <router-link to="/" class="back-button">Back to Home</router-link>

      <!-- Subtitle Section -->
      <p class="subtitle">Welcome to the VCT {{ regionName }} region page!</p>

      <!-- Teams Section -->
      <div v-if="error" class="error">{{ error }}</div>
      <div v-else class="teams-container">
        <router-link
          v-for="team in teams"
          :key="team.id"
          :to="`/team/${team.id}`"
          class="team-card-link"
        >
          <div class="team-card">
            <img :src="team.logoUrl" :alt="team.name" class="team-logo" />
            <h2 class="team-name">{{ team.name }}</h2>
          </div>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import Loading from "@/components/Loading.vue";

export default {
  name: "RegionPage",
  components: {
    Loading,
  },
  props: ["region"],
  data() {
    return {
      teams: [],
      loading: true,
      error: null,
      regionName: "",
      regionLogo: "",
    };
  },
  watch: {
    region: "fetchData",
  },
  async created() {
    await this.initializeRegion();
    await this.fetchData();
  },
  methods: {
    async initializeRegion() {
      const regionMap = {
        americas: {
          name: "Americas",
          logo: "/src/assets/vct-americas-png.png",
        },
        emea: {
          name: "EMEA",
          logo: "/src/assets/vct-emea-png.png",
        },
        china: {
          name: "China",
          logo: "/src/assets/vct-china-png.png",
        },
        pacific: {
          name: "Pacific",
          logo: "/src/assets/vct-pacific-png.png",
        },
      };

      const regionData = regionMap[this.region];
      if (!regionData) {
        this.error = "Invalid region.";
        this.loading = false;
        return;
      }

      this.regionName = regionData.name;
      this.regionLogo = regionData.logo;
    },
    async fetchData() {
      try {
        this.loading = true;
        const response = await axios.get(
          `http://localhost:5128/api/Valorant/teams/${this.region}`
        );
        this.teams = response.data;
      } catch (err) {
        console.error("API Error:", err);
        this.error = "Failed to load teams. Please try again later.";
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>

<style scoped>
.region-page {
  text-align: center;
  padding: 2rem;
  font-family: Arial, sans-serif;
  color: #f4f4f4;
  min-height: 100vh;
}

.header {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 2rem;
}

.header-logo {
  width: 150px;
  height: auto;
  margin-bottom: 1rem;
}

.header-title {
  font-size: 2.5rem;
  color: #ff4655; /* Valorant red */
  text-transform: uppercase;
}

.subtitle {
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
  gap: 3rem;
}

.team-card {
  background-color: #3a3a4d; /* Lighter dark background */
  padding: 1rem;
  border-radius: 8px;
  width: 400px;
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

.team-card-link {
  text-decoration: none;
  color: inherit; /* Ensure text color remains the same */
  display: inline-block;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.team-card-link:hover {
  transform: scale(1.05); /* Subtle zoom effect */
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

/* Valorant font styling */
.valorant-font {
  font-family: "ValorantFont", sans-serif;
  font-weight: bold;
}
.back-button {
  display: inline-block;
  margin-bottom: 2rem;
  padding: 0.5rem 1rem;
  border: none;
  background-color: #ff4655; /* Valorant red */
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
  background-color: #ff6775; /* Slightly lighter red on hover */
  transform: scale(1.05); /* Subtle zoom effect */
}
</style>
