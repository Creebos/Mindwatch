import { defineStore } from "pinia";

export const useMainStore = defineStore("main", {
  state: () => ({
    user: null,
    isLoading: false,
  }),
  actions: {
    setUser(user: any) {
      this.user = user;
    },
    toggleLoading() {
      this.isLoading = !this.isLoading;
    },
  },
});
