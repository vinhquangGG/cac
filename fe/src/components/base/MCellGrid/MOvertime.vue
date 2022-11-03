<template>
  <div>{{dataCell.value == 1 ? "Ca làm 1 lần" : ""}}</div>
</template>

<script>
export default {
    props: {
        dataCell: Object
    }
}
</script>

<style>

</style>