pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        echo 'build'
        sh '''echo "build project"
dotnet publish -c Debug -o ./bin/Debug'''
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