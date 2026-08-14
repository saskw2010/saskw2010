# 🤖 Catalog of 35 Autonomous AI Agents

This document details the exact responsibilities, model routing, and graph connections for all **35 AI Agents** in the enterprise workforce.

---

## 💻 Cluster 1: Engineering & Development (Agents 01 - 07)

| Agent ID & Name | Preferred Model | Primary Responsibility | Obsidian Node Link |
| :--- | :--- | :--- | :--- |
| **01. System Architect Agent** | Gemini 3.6 | High-level system design, schema creation, module boundaries | `[[Agent_01_Architect]]` |
| **02. Backend Developer Agent** | Gemini 3.6 | APIs, Microservices, DB interactions & business logic | `[[Agent_02_BackendDev]]` |
| **03. Frontend UI/UX Agent** | Gemini 3.6 | React/HTML5, Tailwind/CSS3, Glassmorphic UI design | `[[Agent_03_FrontendUI]]` |
| **04. Code Review & QA Agent** | Gemini 3.6 | Static analysis, code quality, linting & syntax safety | `[[Agent_04_CodeReview]]` |
| **05. DevOps & CI/CD Agent** | Qwen 3.6 | Automated pipelines, Docker, GitHub Actions deployment | `[[Agent_05_DevOps]]` |
| **06. Security Auditor Agent** | Gemini 3.6 | Vulnerability scanning, PII protection, Auth checks | `[[Agent_06_Security]]` |
| **07. Database Manager Agent** | Qwen 3.6 | SQL migrations, indexing, vector store optimization | `[[Agent_07_Database]]` |

---

## ⚙️ Cluster 2: Operations & Automation (Agents 08 - 14)

| Agent ID & Name | Preferred Model | Primary Responsibility | Obsidian Node Link |
| :--- | :--- | :--- | :--- |
| **08. Master Task Scheduler** | Qwen 3.6 | Cron scheduling, heartbeat monitoring, task queues | `[[Agent_08_Scheduler]]` |
| **09. Workflow Dispatcher** | Gemini 3.6 | Multi-agent task routing, dependency resolution | `[[Agent_09_Dispatcher]]` |
| **10. Data Ingestion Agent** | Qwen 3.6 | Scraping, RSS feeds, API payload parsing | `[[Agent_10_DataIngest]]` |
| **11. API Gateway Sync** | Qwen 3.6 | External integrations, webhook listeners | `[[Agent_11_APIGateway]]` |
| **12. Health & Uptime Monitor** | Qwen 3.6 | Service pinging, crash recovery, alert triggers | `[[Agent_12_HealthMonitor]]` |
| **13. Backup & Recovery Agent** | Qwen 3.6 | Vault snapshot creation, state persistence | `[[Agent_13_Backup]]` |
| **14. Log Synthesizer Agent** | Qwen 3.6 | Log aggregation, anomaly summaries, incident alerts | `[[Agent_14_LogSynthesizer]]` |

---

## 📚 Cluster 3: Knowledge & Obsidian RAG (Agents 15 - 21)

| Agent ID & Name | Preferred Model | Primary Responsibility | Obsidian Node Link |
| :--- | :--- | :--- | :--- |
| **15. Obsidian Graph Listener** | Gemini 3.6 | File watcher for Markdown vault changes | `[[Agent_15_GraphListener]]` |
| **16. Document Embedder Agent** | Qwen 3.6 | Chunking documents and generating vector embeddings | `[[Agent_16_Embedder]]` |
| **17. Semantic Linker Agent** | Gemini 3.6 | Generating `[[WikiLinks]]` between graph nodes | `[[Agent_17_SemanticLinker]]` |
| **18. Memory Consolidation Agent**| Gemini 3.6 | Episodic memory summarization & long-term retention | `[[Agent_18_MemoryConsolidator]]` |
| **19. Taxonomy & Tagging Agent** | Qwen 3.6 | Tag hygiene, category hierarchy maintenance | `[[Agent_19_Taxonomy]]` |
| **20. Entity Extractor Agent** | Qwen 3.6 | Extracting entities (people, technologies, dates) | `[[Agent_20_EntityExtractor]]` |
| **21. RAG Query Synthesizer** | Gemini 3.6 | Answering complex queries using graph context | `[[Agent_21_RAGQuery]]` |

---

## 📊 Cluster 4: Analytics & Cost Control (Agents 22 - 28)

| Agent ID & Name | Preferred Model | Primary Responsibility | Obsidian Node Link |
| :--- | :--- | :--- | :--- |
| **22. Token Budget Guard** | Qwen 3.6 | Token rate limits, budget enforcement per agent | `[[Agent_22_TokenGuard]]` |
| **23. API Cost Tracker** | Qwen 3.6 | Real-time dollar estimation for model usage | `[[Agent_23_CostTracker]]` |
| **24. Agent Throughput Analyzer**| Qwen 3.6 | Execution time tracking, bottleneck identification | `[[Agent_24_Throughput]]` |
| **25. Trend & Insight Agent** | Gemini 3.6 | Analyzing workflow trends and productivity metrics | `[[Agent_25_TrendAnalyzer]]` |
| **26. Executive Reporting Agent**| Gemini 3.6 | Generating daily/weekly PDF & Markdown reports | `[[Agent_26_ExecutiveReport]]` |
| **27. Anomaly Detector Agent** | Gemini 3.6 | Identifying loop stalls, repetitive prompt waste | `[[Agent_27_AnomalyDetector]]` |
| **28. Efficiency Optimizer Agent**| Gemini 3.6 | Prompt compression, caching strategies | `[[Agent_28_Efficiency]]` |

---

## 🛡️ Cluster 5: Quality, Safety & Supervision (Agents 29 - 35)

| Agent ID & Name | Preferred Model | Primary Responsibility | Obsidian Node Link |
| :--- | :--- | :--- | :--- |
| **29. Output Guardrail Agent** | Gemini 3.6 | Safety policy enforcement, content filtering | `[[Agent_29_Guardrail]]` |
| **30. JSON/Schema Validator** | Qwen 3.6 | Ensuring strict output format compliance | `[[Agent_30_SchemaValidator]]` |
| **31. Fact-Checker Agent** | Gemini 3.6 | Hallucination detection, source verification | `[[Agent_31_FactChecker]]` |
| **32. PII & Privacy Masker** | Qwen 3.6 | Redacting sensitive keys, emails, user tokens | `[[Agent_32_PIIMasker]]` |
| **33. Compliance Checker** | Gemini 3.6 | Organizational policy alignment checks | `[[Agent_33_Compliance]]` |
| **34. Self-Correction Agent** | Gemini 3.6 | Automatic retry & prompt refinement on failure | `[[Agent_34_SelfCorrection]]` |
| **35. Master Supervisor Agent** | Gemini 3.6 | Global orchestration, agent lifecycle management | `[[Agent_35_MasterSupervisor]]` |
