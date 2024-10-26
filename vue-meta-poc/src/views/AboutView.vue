<script setup lang="ts">
import { type MetaInfo } from '../helpers/metaHelper';
import CmsPageViewer from '../components/CmsPageViewer.vue';

const componentMetaInfo = [
        {
            name: 'description',
            content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.'
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
            content: 'About Us'
        }
    ] as MetaInfo[];
   
</script>
<template>
  <cms-page-viewer title="About Us" :meta-info="componentMetaInfo"  />
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
