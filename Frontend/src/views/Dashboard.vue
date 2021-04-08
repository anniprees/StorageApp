<template>
  <div>
    <StorageLocationsList title="Hoiustamiskohad" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import StorageLocationsList from '@/components/StorageLocationsList.vue';

export default defineComponent({
  components: {
    StorageLocationsList,
  },
  setup() {
    return {};
  },
});
</script>
