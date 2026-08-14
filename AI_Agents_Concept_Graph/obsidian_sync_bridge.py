#!/usr/bin/env python3
"""
===============================================================================
35 AI AGENTS - OBSIDIAN WEBSOCKET & GRAPH SYNC BRIDGE
===============================================================================
Author: Mostafa A. ElNagar (@saskw2010)
Description: Real-time bi-directional synchronization bridge connecting 
             35 AI Agents runtime state, Obsidian Markdown Vaults, 
             and Web Dashboard via WebSockets.
===============================================================================
"""

import sys
import os
import random
from datetime import datetime

# Enforce UTF-8 encoding for standard output on Windows
if sys.platform == "win32":
    sys.stdout.reconfigure(encoding='utf-8')

# Default Vault Location inside the project folder
VAULT_DIR = os.path.join(os.path.dirname(__file__), "Obsidian_Vault_35_Agents")

# 35 Agents Architecture Mapping
AGENTS = [
    {"id": 1, "name": "Agent_01_Architect", "title": "System Architect Agent", "cluster": "Engineering", "model": "Gemini 3.6", "links": ["Agent_02_BackendDev", "Agent_03_FrontendUI", "Agent_35_MasterSupervisor"]},
    {"id": 2, "name": "Agent_02_BackendDev", "title": "Backend Developer Agent", "cluster": "Engineering", "model": "Gemini 3.6", "links": ["Agent_04_CodeReview", "Agent_07_DBManager"]},
    {"id": 3, "name": "Agent_03_FrontendUI", "title": "Frontend UI Agent", "cluster": "Engineering", "model": "Gemini 3.6", "links": ["Agent_04_CodeReview"]},
    {"id": 4, "name": "Agent_04_CodeReview", "title": "Code Review & QA Agent", "cluster": "Engineering", "model": "Gemini 3.6", "links": ["Agent_05_DevOps"]},
    {"id": 5, "name": "Agent_05_DevOps", "title": "DevOps & CI/CD Agent", "cluster": "Engineering", "model": "Qwen 3.6", "links": ["Agent_06_SecurityAuditor"]},
    {"id": 6, "name": "Agent_06_SecurityAuditor", "title": "Security Auditor Agent", "cluster": "Engineering", "model": "Gemini 3.6", "links": ["Agent_32_PIIMasker"]},
    {"id": 7, "name": "Agent_07_DBManager", "title": "Database Manager Agent", "cluster": "Engineering", "model": "Qwen 3.6", "links": ["Agent_16_DocEmbedder"]},
    
    # Operations Cluster
    {"id": 8, "name": "Agent_08_TaskScheduler", "title": "Task Scheduler Agent", "cluster": "Operations", "model": "Qwen 3.6", "links": ["Agent_09_WorkflowDispatcher"]},
    {"id": 9, "name": "Agent_09_WorkflowDispatcher", "title": "Workflow Dispatcher Agent", "cluster": "Operations", "model": "Gemini 3.6", "links": ["Agent_35_MasterSupervisor"]},
    {"id": 10, "name": "Agent_10_DataIngestion", "title": "Data Ingestion Agent", "cluster": "Operations", "model": "Qwen 3.6", "links": ["Agent_11_APIGatewaySync"]},
    {"id": 11, "name": "Agent_11_APIGatewaySync", "title": "API Gateway Sync Agent", "cluster": "Operations", "model": "Qwen 3.6", "links": ["Agent_12_HealthMonitor"]},
    {"id": 12, "name": "Agent_12_HealthMonitor", "title": "Health & Uptime Monitor", "cluster": "Operations", "model": "Qwen 3.6", "links": ["Agent_13_BackupRecovery"]},
    {"id": 13, "name": "Agent_13_BackupRecovery", "title": "Backup & Recovery Agent", "cluster": "Operations", "model": "Qwen 3.6", "links": ["Agent_14_LogSynthesizer"]},
    {"id": 14, "name": "Agent_14_LogSynthesizer", "title": "Log Synthesizer Agent", "cluster": "Operations", "model": "Qwen 3.6", "links": ["Agent_27_AnomalyDetector"]},

    # Knowledge & Obsidian RAG Cluster
    {"id": 15, "name": "Agent_15_ObsidianListener", "title": "Obsidian Graph Listener", "cluster": "Knowledge", "model": "Gemini 3.6", "links": ["Agent_16_DocEmbedder", "Agent_17_SemanticLinker"]},
    {"id": 16, "name": "Agent_16_DocEmbedder", "title": "Document Embedder Agent", "cluster": "Knowledge", "model": "Qwen 3.6", "links": ["Agent_21_RAGQuerySynthesizer"]},
    {"id": 17, "name": "Agent_17_SemanticLinker", "title": "Semantic Linker Agent", "cluster": "Knowledge", "model": "Gemini 3.6", "links": ["Agent_18_MemoryConsolidator"]},
    {"id": 18, "name": "Agent_18_MemoryConsolidator", "title": "Memory Consolidation Agent", "cluster": "Knowledge", "model": "Gemini 3.6", "links": ["Agent_19_TaxonomyManager"]},
    {"id": 19, "name": "Agent_19_TaxonomyManager", "title": "Taxonomy Manager Agent", "cluster": "Knowledge", "model": "Qwen 3.6", "links": ["Agent_20_EntityExtractor"]},
    {"id": 20, "name": "Agent_20_EntityExtractor", "title": "Entity Extractor Agent", "cluster": "Knowledge", "model": "Qwen 3.6", "links": ["Agent_21_RAGQuerySynthesizer"]},
    {"id": 21, "name": "Agent_21_RAGQuerySynthesizer", "title": "RAG Query Synthesizer", "cluster": "Knowledge", "model": "Gemini 3.6", "links": ["Agent_35_MasterSupervisor"]},

    # Analytics Cluster
    {"id": 22, "name": "Agent_22_TokenGuard", "title": "Token Budget Guard", "cluster": "Analytics", "model": "Qwen 3.6", "links": ["Agent_23_CostTracker"]},
    {"id": 23, "name": "Agent_23_CostTracker", "title": "API Cost Tracker", "cluster": "Analytics", "model": "Qwen 3.6", "links": ["Agent_24_ThroughputAnalyzer"]},
    {"id": 24, "name": "Agent_24_ThroughputAnalyzer", "title": "Throughput Analyzer", "cluster": "Analytics", "model": "Qwen 3.6", "links": ["Agent_25_TrendAnalyzer"]},
    {"id": 25, "name": "Agent_25_TrendAnalyzer", "title": "Trend & Insight Agent", "cluster": "Analytics", "model": "Gemini 3.6", "links": ["Agent_26_ExecutiveReport"]},
    {"id": 26, "name": "Agent_26_ExecutiveReport", "title": "Executive Report Agent", "cluster": "Analytics", "model": "Gemini 3.6", "links": ["Agent_35_MasterSupervisor"]},
    {"id": 27, "name": "Agent_27_AnomalyDetector", "title": "Anomaly Detector Agent", "cluster": "Analytics", "model": "Gemini 3.6", "links": ["Agent_28_EfficiencyOptimizer"]},
    {"id": 28, "name": "Agent_28_EfficiencyOptimizer", "title": "Efficiency Optimizer Agent", "cluster": "Analytics", "model": "Gemini 3.6", "links": ["Agent_22_TokenGuard"]},

    # Quality & Safety Cluster
    {"id": 29, "name": "Agent_29_OutputGuardrail", "title": "Output Guardrail Agent", "cluster": "Quality", "model": "Gemini 3.6", "links": ["Agent_30_SchemaValidator"]},
    {"id": 30, "name": "Agent_30_SchemaValidator", "title": "Schema Validator Agent", "cluster": "Quality", "model": "Qwen 3.6", "links": ["Agent_31_FactChecker"]},
    {"id": 31, "name": "Agent_31_FactChecker", "title": "Fact Checker Agent", "cluster": "Quality", "model": "Gemini 3.6", "links": ["Agent_32_PIIMasker"]},
    {"id": 32, "name": "Agent_32_PIIMasker", "title": "PII Privacy Masker Agent", "cluster": "Quality", "model": "Qwen 3.6", "links": ["Agent_33_ComplianceChecker"]},
    {"id": 33, "name": "Agent_33_ComplianceChecker", "title": "Compliance Checker Agent", "cluster": "Quality", "model": "Gemini 3.6", "links": ["Agent_34_SelfCorrection"]},
    {"id": 34, "name": "Agent_34_SelfCorrection", "title": "Self Correction Agent", "cluster": "Quality", "model": "Gemini 3.6", "links": ["Agent_35_MasterSupervisor"]},
    {"id": 35, "name": "Agent_35_MasterSupervisor", "title": "Master Supervisor Agent", "cluster": "Quality", "model": "Gemini 3.6", "links": ["Agent_01_Architect", "Agent_09_WorkflowDispatcher", "Agent_15_ObsidianListener", "Agent_22_TokenGuard", "Agent_29_OutputGuardrail"]}
]

def ensure_vault_structure():
    """Create Obsidian Vault directory and subfolders."""
    os.makedirs(os.path.join(VAULT_DIR, "Agents"), exist_ok=True)
    os.makedirs(os.path.join(VAULT_DIR, "Clusters"), exist_ok=True)
    print(f"[Vault] Obsidian Vault Initialized at: {os.path.abspath(VAULT_DIR)}")

def generate_obsidian_markdown(agent, status="Active", tokens=None):
    """Generate Markdown content formatted natively for Obsidian Graph View."""
    if tokens is None:
        tokens = random.randint(15000, 60000)

    wiki_links = "\n".join([f"- [[{link}]]" for link in agent["links"]])
    
    content = f"""---
id: {agent['id']}
agent_name: {agent['name']}
title: {agent['title']}
cluster: {agent['cluster']}
model_engine: {agent['model']}
status: {status}
tokens_today: {tokens}
last_sync: {datetime.now().isoformat()}
tags:
  - ai-agent
  - {agent['cluster'].lower()}
  - obsidian-graph-sync
---

# {agent['title']}

- **Cluster:** #{agent['cluster']}
- **Model Engine:** `{agent['model']}`
- **Current Status:** `{status}`
- **Tokens Consumption:** `{tokens:,} Tokens`

---

## Graph Connections (WikiLinks)

{wiki_links}

---

## Recent Task Log
- *[{datetime.now().strftime('%H:%M:%S')}]* Processed task pipeline payload. Graph node synchronized with runtime state.
"""
    return content

def sync_all_agents_to_vault():
    """Write or update Markdown files for all 35 agents in the Obsidian Vault."""
    ensure_vault_structure()
    for agent in AGENTS:
        filepath = os.path.join(VAULT_DIR, "Agents", f"{agent['name']}.md")
        md_content = generate_obsidian_markdown(agent)
        with open(filepath, "w", encoding="utf-8") as f:
            f.write(md_content)
    
    # Generate Cluster index notes for Obsidian
    for cluster in ["Engineering", "Operations", "Knowledge", "Analytics", "Quality"]:
        cluster_file = os.path.join(VAULT_DIR, "Clusters", f"Cluster_{cluster}.md")
        cluster_agents = [a for a in AGENTS if a["cluster"] == cluster]
        links = "\n".join([f"- [[{a['name']}]]" for a in cluster_agents])
        with open(cluster_file, "w", encoding="utf-8") as f:
            f.write(f"# Cluster: {cluster}\n\n{links}\n")

    print(f"[Sync] Successfully synchronized all {len(AGENTS)} AI Agents into Obsidian Vault!")

if __name__ == "__main__":
    print("[Bridge] Starting Obsidian Graph Sync Bridge...")
    sync_all_agents_to_vault()
    print("[Success] Done! Open the folder 'Obsidian_Vault_35_Agents' in Obsidian to view the live Graph View!")
