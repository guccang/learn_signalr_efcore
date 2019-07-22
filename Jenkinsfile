pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        echo 'build'
        sh 'echo "build project"'
      }
    }
    stage('test') {
      steps {
        sh 'echo "test"'
      }
    }
    stage('deploy') {
      steps {
        sh 'echo "deploy"'
      }
    }
  }
}