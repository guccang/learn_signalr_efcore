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
        sh '''echo "run server" 
cd "D:\\Program Files (x86)\\Jenkins\\workspace\\lr_efcore_test_jenkins_blueocean\\asp_signalR_efcore\\bin\\Debug"
dotnet asp_signalR_efcore.dll &'''
        sleep 10
        sh '''echo "run client"
cd "D:\\Program Files (x86)\\Jenkins\\workspace\\lr_efcore_test_jenkins_blueocean\\signalR_client\\bin\\Debug"
dotnet signalR_client.dll '''
      }
    }
    stage('deploy') {
      steps {
        sh 'echo "deploy"'
      }
    }
  }
}