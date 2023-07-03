<template>
    <div>


    <div class="row">
      <h1>Welcome User, {{ userName }}</h1>
      <br>
    </div>

        <div class="calculator">
        <div class="display">{{ current || '0' }}</div>
        <div @click="clear" class="btn" id="c">C</div>
        <div @click="setOperator(3)" class="btn operator">÷</div>
        <div @click="append('7')" class="btn">7</div>
        <div @click="append('8')" class="btn">8</div>
        <div @click="append('9')" class="btn">9</div>
        <div @click="setOperator(2)" class="btn operator">x</div>
        <div @click="append('4')" class="btn">4</div>
        <div @click="append('5')" class="btn">5</div>
        <div @click="append('6')" class="btn">6</div>
        <div @click="setOperator(1)" class="btn operator">-</div>
        <div @click="append('1')" class="btn">1</div>
        <div @click="append('2')" class="btn">2</div>
        <div @click="append('3')" class="btn">3</div>
        <div @click="setOperator(0)" class="btn operator">+</div>
        <div @click="append('0')" class="btn zero">0</div>
        <div @click="dot" class="btn">.</div>
        <div @click="equal" class="btn operator">=</div>
        </div>
    </div>
  </template>
  
  <script setup>
  import axios from 'axios';
  import { useRoute } from 'vue-router';
  import { ref } from 'vue';
  
  const route = useRoute();
  const userName = route.query.userName;
  
  const previous = ref(null);
  const current = ref('');
  const operator = ref(null);
  const operatorClicked = ref(false);
  
  const clear = () => {
    current.value = '';
  };
  
  const append = (number) => {
    if (operatorClicked.value) {
      current.value = '';
      operatorClicked.value = false;
    }
    current.value = `${current.value}${number}`;
  };
  
  const dot = () => {
    if (current.value.indexOf('.') === -1) {
      append('.');
    }
  };
  
  const setOperator = (op) => {
    operator.value = op;
    setPrevious();
  };
  
  const setPrevious = () => {
    previous.value = current.value;
    operatorClicked.value = true;
  };
  
  const equal = async () => {
    const calculation = {
      number1: previous.value,
      number2: current.value,
      task: operator.value,
      userName: userName,
    };
  
    previous.value = null;
    try {
      const response = await axios.post('https://localhost:7128/api/Test/Calculator', calculation);
      current.value = response.data
    } catch (error) {
      console.log(error);
    }
  };
  </script>
  <style scoped>
.calculator {
  margin: 0 auto;
  width: 400px;
  font-size: 40px;
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  grid-auto-rows: minmax(50px, auto);
}

.display {
  grid-column: 1 / 5;
  background-color: #333;
  color: white;
}

.zero {
  grid-column: 1 / 3;
}
#c {
  grid-column: 1 / 4;
  background-color: orange;
  color: white;
}

.btn {
  background-color: #F2F2F2;
  border: 1px solid #999;
}

.operator {
  background-color: orange;
  color: white;
}
</style>