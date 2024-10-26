<script setup lang="ts">
import { updateMeta, type MetaInfo } from '../helpers/metaHelper';
import { onMounted } from 'vue';

const props = defineProps<{
    title: string,
    metaInfo: MetaInfo[]
}>();

onMounted(() => { 
    updateMeta(props.title, props.metaInfo, true);
})

</script>
<template>
  <div>
    <h1>{{ props.title }}</h1>
  </div>
</template>