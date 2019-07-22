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
        sh '''echo "test"
ls
cd "D:\\Program Files (x86)\\Jenkins\\workspace\\lr_efcore_test_jenkins_blueocean\\asp_signalR_efcore\\bin\\Debug\\netcoreapp2.2"
ls'''
      }
    }
    stage('deploy') {
      steps {
        sh 'echo "deploy"'
      }
    }
  }
}