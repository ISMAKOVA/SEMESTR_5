<template>
  <div id="app">
    <div id="primary-nav">

      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#"></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <a class="nav-link" href="/">Статистика<span class="sr-only">(current)</span></a>
            </li>
<!--            <li class="nav-item">-->
<!--              <router-link to="statistics" class="nav-link">Статистика </router-link>-->
<!--            </li>-->
          </ul>
        </div>
      </nav>
    </div>

    <router-view />
  </div>
</template>
<script>
export default {
  name: "App"
}
</script>

<style>

</style>
