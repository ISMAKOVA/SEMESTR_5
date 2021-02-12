<template>
  <b-container>
    <b-row class="h-100 mt-3">
      <b-col class="">
          <b-card class="mb-3 cur_h"
                   title="Статистика комментариев группы">
            <b-card-text>
              <pie-chart :width="250" :height="250"
                         :chart-data="chartData1"
                         :options="options"></pie-chart>
            </b-card-text>
          </b-card>
          <b-card  class="cur_h"
                   title="Комментарии под последним постом">
            <b-card-text><pie-chart :width="250" :height="250"
                                    :chart-data="chartData2"
                                    :options="options"></pie-chart>
            </b-card-text>
          </b-card>
      </b-col>

      <b-col>
        <b-card  class="h-100"
                 title="Последние комментарии">
          <b-card-text>
            <div class="mt-3" style="height: 37em; overflow: scroll">
            <b-table striped hover :items="items" :fields="fields"></b-table>
          </div></b-card-text>
        </b-card>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import PieChart from "./PieChart.vue";
// import randomColor from 'randomcolor';

const options = {
  responsive: true,
  maintainAspectRatio: false,
  animation: {
    animateRotate: true
  }
}

export default {
name: "Statistics",
  components: {
    PieChart
  },
  data() {
    return {
      options,
      response: [],
      fields: ["Комментарий", "Токсичен"],
      items: [],
      chartData1: {
        labels: ["Токсичные",	"Нетоксичные"],
        datasets: [{
          borderWidth:1,
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)'
          ],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)'
          ],
          data: [1,	2]
        }]
      },
      chartData2: {
        labels: ["Токсичные",	"Нетоксичные"],
        datasets: [{
          borderWidth:1,
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)'
          ],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)'
          ],
          data: [1, 2]
        }]
      },
    };
  },
  methods: {
    getStatistics(){
      this.axios.post("http://127.0.0.1:5000/statistics").then((response) => {
        this.response = response.data;
        console.log(response.data[0]);
        console.log(response.data[1]);
        console.log(response.data[2]);
        this.items = response.data[0];
        this.chartData1.datasets[0].data = response.data[1];
        this.chartData2.datasets[0].data = response.data[2];

      });
    }
  },beforeMount(){
    window.setInterval(() => {
      this.getStatistics()
    }, 1500)

  },
}
</script>

<style scoped>
.cur_h{
  height: 21em;
}
</style>
