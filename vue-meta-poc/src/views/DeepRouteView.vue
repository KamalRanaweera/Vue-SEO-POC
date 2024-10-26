<script setup lang="ts">
import { type MetaInfo } from '../helpers/metaHelper';
import CmsPageViewer from '../components/CmsPageViewer.vue';

const componentMetaInfo = [
        {
            name: 'description',
            content: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
        },
        {
            name: 'robots',
            content: 'index,follow'
        },
        {
            name: 'format-detection',
            content: 'telephone=no'
        },
        {
            property: 'og:site_name',
            content: 'Test Organization'
        },
        {
            property: 'og:title',
            content: 'Deep Route View'
        }
    ] as MetaInfo[];
   
</script>
<template>
  <cms-page-viewer title="Deep Route View" :meta-info="componentMetaInfo"  />
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
