<script>
import { Pie } from 'vue-chartjs'

export default {
  extends: Pie,
  props:['chartData','options'],
  methods: {
    update() {
      this.$data._chart.update()
    }
  },
  mounted () {
    this.renderChart(this.chartData, this.options)
  },
  watch(){
    this.renderChart(this.chartData, this.options)
    this.$data._chart.update()
  }
};
</script>
